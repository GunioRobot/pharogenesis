buildMVCViewOn: aSyntaxError
	"Answer an MVC view on the given SyntaxError."

	| topView aListView aCodeView |
	topView _ StandardSystemView new
		model: aSyntaxError;
		label: 'Syntax Error';
		minimumSize: 380@220.

	aListView _ PluggableListView on: aSyntaxError
		list: #list
		selected: #listIndex
		changeSelected: nil
		menu: #listMenu:.
	aListView window: (0@0 extent: 380@20).
	topView addSubView: aListView.

	aCodeView _ PluggableTextView on: aSyntaxError
		text: #contents
		accept: #contents:notifying:
		readSelection: #contentsSelection
		menu: #codePaneMenu:shifted:.
	aCodeView window: (0@0 extent: 380@200).
	topView addSubView: aCodeView below: aListView.

	^ topView
