createOnForm: aForm
	"Create a StandardSystemView for a FormEditor on the form aForm."
	| formView formEditor menuView aView topView extent topViewBorder |
	topViewBorder _ 2.
	formView _ FormHolderView new model: aForm.
	formEditor _ formView controller.
	menuView _ FormMenuView new makeFormEditorMenu model: formEditor.
	formEditor model: aForm.
	aView _ View new.
	aView model: aForm.
	aView addSubView: formView.
	aView 
		addSubView: menuView
		align: menuView viewport topCenter
		with: formView viewport bottomCenter + (0@16).
	aView window: 
		((formView viewport 
			merge: (menuView viewport expandBy: (16 @ 0 corner: 16@16))) 
		  expandBy: (0@topViewBorder corner: 0@0)).
	topView _ "ColorSystemView" FormEditorView new.
	topView model: formEditor.
	topView backgroundColor: #veryLightGray.
	topView addSubView: aView.
	topView label: 'Form Editor'.
	topView borderWidth: topViewBorder.
	extent _ topView viewport extent.
	topView minimumSize: extent.
	topView maximumSize: extent.
	^topView