openView: topView offsetBy: offset
	"Create change sorter on one changeSet with 0@0.
	Two of these in a DualChangeSorter, right one is offset by 360@0."
	| classView messageView codeView |
	buttonView _ SwitchView new.
	buttonView model: self controller: TriggerController new.
	buttonView borderWidthLeft: 2 right: 2 top: 2 bottom: 0.
	buttonView selector: #whatPolarity.
	buttonView controller selector: #cngSetActivity.
	buttonView window: ((0 @ 0 extent: 360 @ 20) translateBy: offset).
	buttonView label: myChangeSet name asParagraph.

	classView _ GeneralListView new.
	classView controllerClass: GeneralListController.
	classView model: classList.
	classView window: (0 @ 0 extent: 180 @ 160).
	classView borderWidthLeft: 2 right: 0 top: 2 bottom: 2.
	classView controller yellowButtonMenu: ClassMenu 
		yellowButtonMessages: ClassSelectors.
	classList controller: classView controller.

	messageView _ GeneralListView new.
	messageView controllerClass: GeneralListController.
	messageView model: messageList.
	messageView window: (0 @ 0 extent: 180 @ 160).
	messageView borderWidthLeft: 2 right: 2 top: 2 bottom: 2.
	messageView controller yellowButtonMenu: MsgListMenu 
		yellowButtonMessages: MsgListSelectors.
	messageList controller: messageView controller.

	codeView _ BrowserCodeView new.
	codeView model: self.
	codeView window: (0 @ 0 extent: 360 @ 180).
	codeView borderWidthLeft: 2 right: 2 top: 0 bottom: 2.

	topView addSubView: buttonView.
	topView addSubView: classView below: buttonView.
	topView addSubView: messageView toRightOf: classView.
	topView addSubView: codeView below: classView.
