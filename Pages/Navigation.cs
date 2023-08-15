// Navigation.cs
// Copyright (C) 2023-2023 Sienna Lloyd
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as published
// by the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Affero General Public License for more details.
// 
// You should have received a copy of the GNU Affero General Public License

namespace retrans.Pages;

public interface INavigationItem {
    public string Title { get; set; }            ////This pairs with ShellItem.Title
    public DataTemplate Template { get; set; }   ////This pairs with ShellItem.ContentTemplate
    public ImageSource Image { get; set; }       ////This pairs with ShellItem.Icon
    public string Route { get; set; }            ////This pairs with ShellItem.Route
    public List<ShellSection> Tabs { get; set; } ////This pairs with ShellItem.Tab

    public bool HasImage => Image != null;         ////These are optional, and just for validation purpose
    public bool HasNavigation => Template != null; ////These are optional, and just for validation purpose
    public bool HasTabs => Tabs != null;           ////These are optional, and just for validation purpose
}

public class Navigation {
    public Navigation() { NavigationItems = new List<INavigationItem>(); }

    public IEnumerable<INavigationItem> NavigationItems { get; private set; }

    public void AddNavigablePage(INavigationItem item) { NavigationItems = NavigationItems.Append(item); }

    public IEnumerable<FlyoutItem> Build() {
        var final = new List<FlyoutItem>();

        foreach (var item in NavigationItems) {
            var f = new FlyoutItem { Title = item.Title };
            item.Tabs.ForEach(x => f.Items.Add(x));
            final.Add(f);
        }

        return final;
    }
}
