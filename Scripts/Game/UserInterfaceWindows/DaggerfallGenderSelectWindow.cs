﻿// Project:         Daggerfall Tools For Unity
// Copyright:       Copyright (C) 2009-2015 Daggerfall Workshop
// Web Site:        http://www.dfworkshop.net
// License:         MIT License (http://www.opensource.org/licenses/mit-license.php)
// Source Code:     https://github.com/Interkarma/daggerfall-unity
// Original Author: Gavin Clayton (interkarma@dfworkshop.net)
// Contributors:    
// 
// Notes:
//

using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using DaggerfallConnect;
using DaggerfallConnect.Arena2;
using DaggerfallWorkshop;
using DaggerfallWorkshop.Game.UserInterface;
using DaggerfallWorkshop.Game.Entity;
using DaggerfallWorkshop.Game.Player;

namespace DaggerfallWorkshop.Game.UserInterfaceWindows
{
    /// <summary>
    /// Implements gender select popup window.
    /// </summary>
    public class DaggerfallGenderSelectWindow : DaggerfallMessageBox
    {
        const int strSelectThyCharactersGender = 2200;

        public Genders SelectedGender { get; private set; }

        public DaggerfallGenderSelectWindow(IUserInterfaceManager uiManager, DaggerfallBaseWindow previous = null)
            : base(uiManager, previous)
        {
        }

        protected override void Setup()
        {
            base.Setup();

            TextFile.Token[] textTokens = DaggerfallUnity.Instance.TextProvider.GetRSCTokens(strSelectThyCharactersGender);
            SetTextTokens(textTokens);

            Button maleButton = AddButton(MessageBoxButtons.Male);
            Button femaleButton = AddButton(MessageBoxButtons.Female);

            maleButton.OnMouseClick += MaleButton_OnMouseClick;
            femaleButton.OnMouseClick += FemaleButton_OnMouseClick;
        }

        void MaleButton_OnMouseClick(BaseScreenComponent sender, Vector2 position)
        {
            SelectedGender = Genders.Male;
        }

        void FemaleButton_OnMouseClick(BaseScreenComponent sender, Vector2 position)
        {
            SelectedGender = Genders.Female;
        }

        public override void Update()
        {
            base.Update();
        }
    }
}