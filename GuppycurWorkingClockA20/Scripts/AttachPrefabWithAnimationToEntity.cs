using System;
using System.Xml;
using UnityEngine;
using Harmony;

public class MinEventActionAttachPrefabWithAnimationsToEntity : MinEventActionAttachPrefabToEntity
{
    public override void Execute(MinEventParams _params)
    {
        //if (_params.Self.RootTransform != null )
        if (_params.Self != null || _params.Self.RootTransform != null)
        {
            Animator[] componentsInChildren = _params.Self.RootTransform.GetComponentsInChildren<Animator>();
            for (int i = componentsInChildren.Length - 1; i >= 0; i--)
            {
                Animator animator = componentsInChildren[i];
                animator.enabled = true;
                if (animator.gameObject.GetComponent<BlockClockScript>() == null)
                    animator.gameObject.AddComponent<BlockClockScript>();
            }
        }

        base.Execute( _params);
    }
}

public class BlockClockDMT : Block
{
    public override void ForceAnimationState(BlockValue _blockValue, BlockEntityData _ebcd)
    {
        if (_ebcd != null && _ebcd.bHasTransform)
        {
            Animator[] componentsInChildren = _ebcd.transform.GetComponentsInChildren<Animator>();
            for (int i = componentsInChildren.Length - 1; i >= 0; i--)
            {
                Animator animator = componentsInChildren[i];
                animator.enabled = true;
                if ( animator.gameObject.GetComponent<BlockClockScript>() == null)
                    animator.gameObject.AddComponent<BlockClockScript>();
            }
        }
    }
}
