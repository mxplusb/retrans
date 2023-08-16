// AzureLocations.cs
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

namespace retrans.Utils;

public class Metadata {
    public string geographyGroup { get; set; }
    public string latitude { get; set; }
    public string longitude { get; set; }
    public List<PairedRegion> pairedRegion { get; set; }
    public string physicalLocation { get; set; }
    public string regionCategory { get; set; }
    public string regionType { get; set; }
}

public class PairedRegion {
    public string id { get; set; }
    public string name { get; set; }
    public object subscriptionId { get; set; }
}

public class AzureLocations {
    public string displayName { get; set; }
    public string id { get; set; }
    public Metadata metadata { get; set; }
    public string name { get; set; }
    public string regionalDisplayName { get; set; }
    public object subscriptionId { get; set; }
}
