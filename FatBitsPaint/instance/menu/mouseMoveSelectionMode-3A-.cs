mouseMoveSelectionMode: evt

        | p |
        p _ self griddedPoint: evt.
        lastMouse = p ifTrue: [^ self].

        currentSelectionMorph ifNil:
                [currentSelectionMorph _ MarqueeMorph new 
                        color: Color transparent;
                        borderWidth: 2;
                        lock.
                self addMorphFront: currentSelectionMorph.
                currentSelectionMorph startStepping].
        currentSelectionMorph 
                bounds: ((Rectangle encompassing: {p. selectionAnchor}) translateBy: self position).

        lastMouse _ p