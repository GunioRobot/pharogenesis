openEditString: aString
        "Create a pluggable version of all the views for a Browser, including views and controllers."
        | systemCategoryListView classListView 
        messageCategoryListView messageListView browserCodeView topView switchView underPane y optionalButtonsView annotationPane |

        self couldOpenInMorphic ifTrue: [^ self openAsMorphEditing: aString].
        "Sensor leftShiftDown ifTrue: [^ self openAsMorphEditing: aString].
                uncomment-out for testing morphic browser embedded in mvc project"

        topView _ StandardSystemView new model: self.
        topView borderWidth: 1. "label and minSize taken care of by caller"

        systemCategoryListView _ PluggableListView on: self
                list: #systemCategoryList
                selected: #systemCategoryListIndex
                changeSelected: #systemCategoryListIndex:
                menu: #systemCategoryMenu:
                keystroke: #systemCatListKey:from:.
        systemCategoryListView window: (0 @ 0 extent: 50 @ 70).
        topView addSubView: systemCategoryListView.

        classListView _ PluggableListView on: self
                list: #classList
                selected: #classListIndex
                changeSelected: #classListIndex:
                menu: #classListMenu:shifted:
                keystroke: #classListKey:from:.
        classListView window: (0 @ 0 extent: 50 @ 62).
        topView addSubView: classListView toRightOf: systemCategoryListView.

        switchView _ self buildInstanceClassSwitchView.
        switchView borderWidth: 1.
        topView addSubView: switchView below: classListView.

        messageCategoryListView _ PluggableListView on: self
                list: #messageCategoryList
                selected: #messageCategoryListIndex
                changeSelected: #messageCategoryListIndex:
                menu: #messageCategoryMenu:.
        messageCategoryListView window: (0 @ 0 extent: 50 @ 70).
        topView addSubView: messageCategoryListView toRightOf: classListView.

        messageListView _ PluggableListView on: self
                list: #messageList
                selected: #messageListIndex
                changeSelected: #messageListIndex:
                menu: #messageListMenu:shifted:
                keystroke: #messageListKey:from:.
        messageListView window: (0 @ 0 extent: 50 @ 70).
        messageListView menuTitleSelector: #messageListSelectorTitle.
        topView addSubView: messageListView toRightOf: messageCategoryListView.

       self wantsAnnotationPane
                ifTrue:
                        [annotationPane _ PluggableTextView on: self
                                text: #annotation accept: nil
                                readSelection: nil menu: nil.
                        annotationPane window: (0@0 extent: 200@self optionalAnnotationHeight).
                        topView addSubView: annotationPane below: systemCategoryListView.
                        underPane _ annotationPane.
                        y _ 110 - self optionalAnnotationHeight]
                ifFalse: [
                        underPane _ systemCategoryListView.
                        y _ 110].

        self wantsOptionalButtons ifTrue:
                [optionalButtonsView _ self buildOptionalButtonsView.
                optionalButtonsView borderWidth: 1.
                topView addSubView: optionalButtonsView below: underPane.
                underPane _ optionalButtonsView.
                y _ y - self optionalButtonHeight].

        browserCodeView _ PluggableTextView on: self 
                        text: #contents accept: #contents:notifying:
                        readSelection: #contentsSelection menu: #codePaneMenu:shifted:.
        browserCodeView window: (0@0 extent: 200@y).
        topView addSubView: browserCodeView below: underPane.
        aString ifNotNil: [browserCodeView editString: aString.
                        browserCodeView hasUnacceptedEdits: true].
        topView setUpdatablePanesFrom: #(systemCategoryList classList messageCategoryList messageList).

        ^ topView