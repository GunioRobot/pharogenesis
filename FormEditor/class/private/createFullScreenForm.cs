createFullScreenForm
	"Create a StandardSystemView for a FormEditor on the form whole screen."
	| formView formEditor menuView topView extent aForm |
	aForm _ Form extent: (Display extent x @ (Display extent y - 112)) depth: Display depth.
	formView _ FormHolderView new model: aForm.
	formView borderWidthLeft: 0 right: 0 top: 0 bottom: 1.
	formEditor _ formView controller.
	menuView _ FormMenuView new makeFormEditorMenu model: formEditor.
	formEditor model: menuView controller.
	topView _ StandardSystemView new.
	topView backgroundColor: #veryLightGray.
	topView model: aForm.
	topView addSubView: formView.
	topView 
		addSubView: menuView
		align: menuView viewport topCenter
		with: formView viewport bottomCenter + (0@16).
	topView window: 
		(formView viewport 
			merge: (menuView viewport expandBy: (16 @ 0 corner: 16@16))).
	topView label: 'Form Editor'.
	extent _ topView viewport extent.
	topView minimumSize: extent.
	topView maximumSize: extent.
	^topView

