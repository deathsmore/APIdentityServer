// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using System;

namespace IdentityServerHost.Quickstart.UI
{
    public class AccountOptions
    {
        public static bool AllowLocalLogin = true;
        public static bool AllowRememberLogin = true;
        public static TimeSpan RememberMeLoginDuration = TimeSpan.FromDays(30);

        public static bool ShowLogoutPrompt = false;//Không hiện view thông báo đã logout
        public static bool AutomaticRedirectAfterSignOut = true;//Tự động redirect về client sau khi IS4 logout

        public static string InvalidCredentialsErrorMessage = "Invalid username or password";
    }
}
