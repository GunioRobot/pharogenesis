open: aStringHolder label: aString 
	"Create a standard system view of the model, aStringHolder, as viewed by 
	an instance of me. The label of the view is aString."
	| aStringHolderView topView |
	aStringHolderView _ self container: aStringHolder.
	topView _ StandardSystemView new.
	topView model: aStringHolderView model.
	topView addSubView: aStringHolderView.
	topView label: aString.
	topView minimumSize: 100 @ 50.
	topView controller open