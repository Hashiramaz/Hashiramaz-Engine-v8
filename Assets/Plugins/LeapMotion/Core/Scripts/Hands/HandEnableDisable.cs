/******************************************************************************
 * Copyright (C) Ultraleap, Inc. 2011-2020.                                   *
 *                                                                            *
 * Use subject to the terms of the Apache License 2.0 available at            *
 * http://www.apache.org/licenses/LICENSE-2.0, or another agreement           *
 * between Ultraleap and you, your company or other organization.             *
 ******************************************************************************/

using UnityEngine;
using System.Collections;
using System;
using Leap;
using Lean.Gui;
namespace Leap.Unity{
  public class HandEnableDisable : HandTransitionBehavior {
    public LeanToggle handToggle;
    protected override void Awake() {
      base.Awake();
      //gameObject.SetActive(false);
      handToggle.On = false;
    }

  	protected override void HandReset() {
      //gameObject.SetActive(true);
      handToggle.On = true;
    }

    protected override void HandFinish() {
      //gameObject.SetActive(false);
      handToggle.On = false;
    }

  }
}
