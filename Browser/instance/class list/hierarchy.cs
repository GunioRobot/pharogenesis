hierarchy
        "Display the inheritance hierarchy of the receiver's selected class."

        classListIndex = 0 ifTrue: [^ self].
        self okToChange ifFalse: [^ self].
        self messageCategoryListIndex: 0.
        editSelection := #hierarchy.
        self changed: #editComment.
        ^ self