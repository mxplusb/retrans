﻿// AppDelegate.cs
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

#region

using Foundation;

#endregion

namespace retrans;

[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate {
    protected override MauiApp CreateMauiApp() { return MauiProgram.CreateMauiApp(); }
}
