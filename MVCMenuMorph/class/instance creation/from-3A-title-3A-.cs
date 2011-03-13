from: aPopupMenu title: titleStringOrNil
	"Answer a MenuMorph constructed from the given PopUpMenu. Used to simulate MVC-style menus in a Morphic-only world."

	| menu items lines selections labelString j emphasis |
	menu _ self new.
	titleStringOrNil ifNotNil: [
		titleStringOrNil isEmpty ifFalse: [menu addTitle: titleStringOrNil]].
	labelString _ aPopupMenu labelString.
	items _ labelString asString findTokens: String cr.
	labelString isText ifTrue:
		["Pass along text emphasis if present"
		j _ 1.
		items _ items collect:
			[:item | j _ labelString asString findString: item startingAt: j.
			emphasis _ TextEmphasis new emphasisCode: (labelString emphasisAt: j).
			item asText addAttribute: emphasis]].
	lines _ aPopupMenu lineArray.
	lines ifNil: [lines _ #()].
	menu cancelValue: 0.
	menu defaultTarget: menu.
	selections _ (1 to: items size) asArray.
	1 to: items size do: [:i |
		menu add: (items at: i) selector: #selectMVCItem: argument: (selections at: i).
		(lines includes: i) ifTrue: [menu addLine]].
	^ menu
