openEditString: aString
        "Create a pluggable version of all the views for a Browser, including views and controllers."
        | systemCategoryListView classListView 
        messageCategoryListView messageListView browserCodeView topView switchView underPane y optionalButtonsView annotationPane |

        self couldOpenInMorphic ifTrue: [^ self openAsMorphEditing: aString].
        "Sensor leftShiftDown ifTrue: [^ self openAsMorphEditing: aString].
                uncomment-out for testing morphic browser embedded in mvc project"

        topView := StandardSystemView new model: self.
        topView borderWidth: 1. "label and minSize taken care of by caller"

        systemCategoryListView := PluggableListView on: self
                list: #systemCategoryList
                selected: #systemCategoryListIndex
                changeSelected: #systemCategoryListIndex:
                menu: #systemCategoryMenu:
                keystroke: #systemCatListKey:from:.
        systemCategoryListView window: (0 @ 0 extent: 50 @ 70).
        topView addSubView: systemCategoryListView.

        classListView := PluggableListView on: self
                list: #classList
                selected: #classListIndex
                changeSelected: #classListIndex:
                menu: #classListMenu:shifted:
                keystroke: #classListKey:from:.
        classListView window: (0 @ 0 extent: 50 @ 62).
        topView addSubView: classListView toRightOf: systemCategoryListView.

        switchView := self buildInstanceClassSwitchView.
        switchView borderWidth: 1.
        topView addSubView: switchView below: classListView.

        messageCategoryListView := PluggableListView on: self
                list: #messageCategoryList
                selected: #messageCategoryListIndex
                changeSelected: #messageCategoryListIndex:
                menu: #messageCategoryMenu:. 
        messageCategoryListView controller terminateDuringSelect: true.
        messageCategoryListView window: (0 @ 0 extent: 50 @ 70).
        topView addSubView: messageCategoryListView toRightOf: classListView.

        messageListView := PluggableListView on: self
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
                        [annotationPane := PluggableTextView on: self
                                text: #annotation accept: nil
                                readSelection: nil menu: nil.
                        annotationPane window: (0@0 extent: 200@self optionalAnnotationHeight).
                        topView addSubView: annotationPane below: systemCategoryListView.
                        underPane := annotationPane.
                        y := 110 - self optionalAnnotationHeight]
                ifFalse: [
                        underPane := systemCategoryListView.
                        y := 110].

        self wantsOptionalButtons ifTrue:
                [optionalButtonsView := self buildOptionalButtonsView.
                optionalButtonsView borderWidth: 1.
                topView addSubView: optionalButtonsView below: underPane.
                underPane := optionalButtonsView.
                y := y - self optionalButtonHeight].

        browserCodeView := MvcTextEditor default on: self 
                        text: #contents accept: #contents:notifying:
                        readSelection: #contentsSelection menu: #codePaneMenu:shifted:.
        browserCodeView window: (0@0 extent: 200@y).
        topView addSubView: browserCodeView below: underPane.
        aString ifNotNil: [browserCodeView editString: aString.
                        browserCodeView hasUnacceptedEdits: true].
        topView setUpdatablePanesFrom: #(systemCategoryList classList messageCategoryList messageList).

        ^ topView