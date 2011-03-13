menuMorphWithTitle: titleStringOrNil 
	"Answer a MenuMorph constructed from self
	The menu is build so that it is forced to return 
	the current selection value when an item is selected"
	| menu items lines allSelections j emphasis |
	menu := MenuMorph new.
	titleStringOrNil isEmptyOrNil ifFalse: [menu addTitle: titleStringOrNil].
	labelString := self labelString.
	items := self labelString asString findTokens: String cr.
	self labelString isText
		ifTrue: ["Pass along text emphasis if present"
			j := 1.
			items := items
						collect: [:item | 
							j := self labelString asString findString: item startingAt: j.
							emphasis := TextEmphasis new emphasisCode: (self labelString emphasisAt: j).
							item asText addAttribute: emphasis]].
	lines := self lineArray ifNil: [#()].
	menu defaultTarget: menu.
	allSelections := (1 to: items size) asArray.
	1
		to: items size
		do: [:i | 
			menu add: (items at: i) target: (allSelections at: i) selector: #yourself.
			(lines includes: i)
				ifTrue: [menu addLine]].
	^ menu