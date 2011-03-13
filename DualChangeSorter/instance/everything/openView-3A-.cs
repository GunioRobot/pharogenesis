openView: topView
	"Create views of dual side-by-side change sorter views"
	| leftView rightView |

	leftView _ View new.
	leftView model: leftCngSorter.
	leftView window: (0 @ 0 extent: 360 @ 360).
	leftView borderWidthLeft: 0 right: 0 top: 0 bottom: 0.
	leftCngSorter openView: leftView.


	rightView _ View new.
	rightView model: rightCngSorter.
	rightView window: (0 @ 0 extent: 360 @ 360).
	rightView borderWidthLeft: 0 right: 0 top: 0 bottom: 0.
	rightCngSorter openView: rightView.

	topView addSubView: leftView.
	topView addSubView: rightView.

	" leftView 
		align: leftView viewport topLeft 	
		with: topView viewport topLeft. "
	rightView 
		align: rightView viewport topLeft 	
		with: leftView viewport topRight.
