openAsMorphIn: window  "PDA new openAsMorph openInWorld"
	"Create a pluggable version of all the morphs for a Browser in Morphic"
	| dragNDropFlag paneColor chooser |
	window color: Color black.
	paneColor _ (Color r: 0.6 g: 1.0 b: 0.0).
	window model: self.
	Preferences alternativeWindowLook ifTrue:[
		window color: Color white.
		window paneColor: paneColor].
	dragNDropFlag _ Preferences browseWithDragNDrop.
	window addMorph: ((PluggableListMorph on: self list: #peopleListItems
			selected: #peopleListIndex changeSelected: #peopleListIndex:
			menu: #peopleMenu: keystroke: #peopleListKey:from:) enableDragNDrop: dragNDropFlag)
		frame: (0@0 corner: 0.3@0.25).
	window addMorph: ((chooser _ PDAChoiceMorph new color: paneColor) contentsClipped: 'all';
			target: self; actionSelector: #chooseFrom:categoryItem:; arguments: {chooser};
			getItemsSelector: #categoryChoices)
		frame: (0@0.25 corner: 0.3@0.3).
	window addMorph: ((MonthMorph newWithModel: self) color: paneColor; extent: 148@109)
		frame: (0.3@0 corner: 0.7@0.3).
	window addMorph: (PDAClockMorph new color: paneColor;
						faceColor: (Color r: 0.4 g: 0.8 b: 0.6))  "To match monthMorph"
		frame: (0.7@0 corner: 1.0@0.3).

	window addMorph: ((PluggableListMorph on: self list: #toDoListItems
			selected: #toDoListIndex changeSelected: #toDoListIndex:
			menu: #toDoMenu: keystroke: #toDoListKey:from:) enableDragNDrop: dragNDropFlag)
		frame: (0@0.3 corner: 0.3@0.7).
	window addMorph: ((PluggableListMorph on: self list: #scheduleListItems
			selected: #scheduleListIndex changeSelected: #scheduleListIndex:
			menu: #scheduleMenu: keystroke: #scheduleListKey:from:) enableDragNDrop: dragNDropFlag)
		frame: (0.3@0.3 corner: 0.7@0.7).
	window addMorph: ((PluggableListMorph on: self list: #notesListItems
			selected: #notesListIndex changeSelected: #notesListIndex:
			menu: #notesMenu: keystroke: #notesListKey:from:) enableDragNDrop: dragNDropFlag)
		frame: (0.7@0.3 corner: 1@0.7).

	window addMorph: (PluggableTextMorph on: self
			text: #currentItemText accept: #acceptCurrentItemText:
			readSelection: #currentItemSelection menu: #currentItemMenu:)
		frame: (0@0.7 corner: 1@1).
	Preferences alternativeWindowLook ifFalse:[
		window firstSubmorph color: paneColor.
	].
	window updatePaneColors.
	window step.
	^ window