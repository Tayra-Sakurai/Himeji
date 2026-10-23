// SPDX-FileCopyrightText: 2026 Tayra Sakurai
// SPDX-License-Identifier: AGPL-3.0-or-later

using Microsoft.UI.Xaml.Controls;
using Microsoft.Windows.ApplicationModel.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace Himeji
{
    public class PageIndex
    {
        private string title = string.Empty;

        public string PageTitle
        {
            get
            {
                if (!string.IsNullOrEmpty(ResourceName))
                {
                    ResourceLoader resourceLoader = new();
                    return resourceLoader.GetString(ResourceName);
                }
                return title;
            }

            set
            {
                title = value;
            }
        }

        public string ResourceName { private get; set; } = string.Empty;

        public IconElement? IconElement { get; init; }

        public required Type PageType { get; init; }
    }
}
