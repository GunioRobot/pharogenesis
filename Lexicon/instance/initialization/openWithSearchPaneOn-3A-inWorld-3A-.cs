openWithSearchPaneOn: aTargetClass  inWorld: aWorld
	"Create and open a SystemWindow to house the receiver, search-pane variant.  Only sender is currently unsent; a disused branch but still for the moment retained"

	| window aListMorph aTextMorph baseline typeInPane |

	targetClass _ aTargetClass.
	window _ self windowWithLabel: 'Vocabulary of ', aTargetClass nameForViewer.

	window addMorph: self newSearchPane frame: (0@0 extent: 1@0.05).

	aListMorph _ PluggableListMorph on: self list: #messageList
			selected: #messageListIndex changeSelected: #messageListIndex:
			menu: #messageListMenu:shifted:
			keystroke: #messageListKey:from:.
	aListMorph menuTitleSelector: #messageListSelectorTitle.
	window addMorph: aListMorph frame: (0@0.05 extent: 1@0.25).

	 self wantsAnnotationPane
		ifFalse:
			[baseline  _ 0.25]
		ifTrue:
			[aTextMorph _ PluggableTextMorph on: self
					text: #annotation accept: nil
					readSelection: nil menu: nil.
			aTextMorph askBeforeDiscardingEdits: false.
			window addMorph: aTextMorph
				frame: (0@0.25 corner: 1@0.35).
			baseline _ 0.35].
	self wantsOptionalButtons
		ifTrue:
			[window addMorph: self optionalButtonRow frame: ((0@baseline corner: 1 @ (baseline + 0.08))).
			baseline _ baseline + 0.08].

	typeInPane _ PluggableTextMorph on: self 
			text: #contents accept: #contents:notifying:
			readSelection: #contentsSelection menu: #codePaneMenu:shifted:.
	typeInPane retractable: false.
	window addMorph: typeInPane
		frame: (0 @ baseline corner: 1 @ 1).

	window setUpdatablePanesFrom: #(messageList).
	window openInWorld: aWorld.
	self flag: #deferred.

	"self initListFrom: aTargetClass allCategoriesInProtocol asSortedCollection highlighting: aTargetClass"
	
"(Lexicon new useProtocol: Protocol fullProtocol) openWithSearchPaneOn: TileMorph  inWorld: self currentWorld"

