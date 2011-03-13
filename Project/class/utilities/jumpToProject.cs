jumpToProject
	"Present a list of potential projects and enter the one selected."
	"Project jumpToProject"

	| selection menu |
	menu _ CustomMenu new.
	CurrentProject previousProject ifNotNil: [
		menu add: 'previous project' action: #previous].
	CurrentProject isTopProject ifFalse: [
		menu add: 'parent project' action: #parent].
	menu addLine.
	Project allNames do: [:n | menu add: n action: n].
	selection _ menu startUp.
	selection ifNotNil: [
		selection = #previous ifTrue: [^ self returnToPreviousProject].
		selection = #parent ifTrue: [CurrentProject parent enter: false. ^ self].
		(Project named: selection) enter: false].
