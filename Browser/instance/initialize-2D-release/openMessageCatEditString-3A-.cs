openMessageCatEditString: aString
        "Create a pluggable version of the views for a Browser that just shows one message category."
        | messageCategoryListView messageListView browserCodeView topView annotationPane underPane y optionalButtonsView |

        self couldOpenInMorphic ifTrue: [^ self openAsMorphMsgCatEditing: aString].

        topView := (StandardSystemView new) model: self.
        topView borderWidth: 1.
                "label and minSize taken care of by caller"

        messageCategoryListView := PluggableListView on: self
                list: #messageCatListSingleton
                selected: #indexIsOne 
                changeSelected: #indexIsOne:
                menu: #messageCategoryMenu:.
        messageCategoryListView window: (0 @ 0 extent: 200 @ 12).
        topView addSubView: messageCategoryListView.

        messageListView := PluggableListView on: self
                list: #messageList
                selected: #messageListIndex
                changeSelected: #messageListIndex:
                menu: #messageListMenu:shifted:
                keystroke: #messageListKey:from:.
        messageListView menuTitleSelector: #messageListSelectorTitle.
        messageListView window: (0 @ 0 extent: 200 @ 70).
        topView addSubView: messageListView below: messageCategoryListView.

        self wantsAnnotationPane
                ifTrue:
                        [annotationPane := PluggableTextView on: self
                                text: #annotation accept: nil
                                readSelection: nil menu: nil.
                        annotationPane window: (0@0 extent: 200@self optionalAnnotationHeight).
                        topView addSubView: annotationPane below: messageListView.
                        underPane := annotationPane.
                        y := (200 - 12 - 70) - self optionalAnnotationHeight]
                ifFalse:
                        [underPane := messageListView.
                        y := (200 - 12 - 70)].

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
        topView setUpdatablePanesFrom: #(messageCatListSingleton messageList).
        ^ topView