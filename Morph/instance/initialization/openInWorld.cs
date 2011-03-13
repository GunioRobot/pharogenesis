openInWorld
        "Add this morph to the world.  If in MVC, then provide a Morphic window for it."

        self couldOpenInMorphic
                ifTrue: [self openInWorld: self currentWorld]
                ifFalse: [self openInMVC]