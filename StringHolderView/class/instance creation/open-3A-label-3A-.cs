open: aStringHolder label: labelString 
	"NOTE this should be in the model class, and all senders so redirected,
	in order that the view class can be discarded in a morphic world."

	"Create a standard system view of the model, aStringHolder, as viewed by 
	an instance of me. The label of the view is aString."
	| aStringHolderView topView |

	Smalltalk isMorphic ifTrue: [^ aStringHolder openAsMorphLabel: labelString].

	aStringHolderView _ self container: aStringHolder.
	topView _ StandardSystemView new.
	topView model: aStringHolderView model.
	topView addSubView: aStringHolderView.
	topView label: labelString.
	topView minimumSize: 100 @ 50.
	topView controller open