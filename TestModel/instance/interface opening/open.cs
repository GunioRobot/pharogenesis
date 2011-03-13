open
	"doIt: [TestModel new open]"

	| topWindowV runButtonV detailsTextV failureListV errorListV |

	self updateColorSelector: #updateColorV.

	"=== build the parts ... ==="
	(topWindowV := StandardSystemView new)
		label: self windowLabel;
		model: self.
	self patternTextV: (PluggableTextView
		on: self
		text: #patternText
		accept: #patternText:
		readSelection: nil
		menu: #patternHistoryMenuMVC:).
	runButtonV := PluggableButtonView
		on: self
		getState: #runButtonState
		action: #runTests
		label: #runButtonLabel.
	runButtonV
		label: self runButtonLabel;
		insideColor: self runButtonColor.
	self summaryTextV: (PluggableTextView
		on: self
		text: #summaryText
		accept: nil).
	detailsTextV := PluggableTextView on: self
		text: #detailsText
		accept: nil.
	failureListV := PluggableListView
		on: self
		list: #failureList
		selected: #failureListSelectionIndex
		changeSelected: #failureListSelectionIndex:.
	errorListV := PluggableListView
		on: self
		list: #errorList
		selected: #errorListSelectionIndex
		changeSelected: #errorListSelectionIndex:.

	"=== size the parts ... ==="
	self patternTextV
		borderWidth: 1;
		window: (0@0 corner: 100@10). "(0.0@0.0 extent: 1.0@0.1)"
	runButtonV
		borderWidth: 1;
		window: (0@0 corner: 20@10). "(0.0@0.1 extent: 0.2@0.1)"
	self summaryTextV
		borderWidth: 1;
		window: (0@0 corner: 80@10). "(0.2@0.1 extent: 0.8@0.1)"
	detailsTextV
		borderWidth: 1;
		window: (0@0 corner: 100@10). "(0.0@0.2 extent: 1.0@0.1)"
	failureListV
		borderWidth: 1;
		window: (0@0 corner: 100@35). "(0.0@0.3 extent: 1.0@0.35)"
	errorListV
		borderWidth: 1;
		window: (0@0 corner: 100@35). "(0.0@0.65 extent: 1.0@0.35)"

	"=== assemble the whole ... ==="
	topWindowV
		addSubView: self patternTextV;
		addSubView: runButtonV below: self patternTextV;
		addSubView: self summaryTextV toRightOf: runButtonV;
		addSubView: detailsTextV below: runButtonV;
		addSubView: failureListV below: detailsTextV;
		addSubView: errorListV below: failureListV.

	"=== open it ... ==="
	topWindowV minimumSize: 200@200.
	topWindowV maximumSize: 250@200.
	topWindowV controller open.