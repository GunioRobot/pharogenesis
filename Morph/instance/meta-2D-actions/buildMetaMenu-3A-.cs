buildMetaMenu: evt
	"Build the morph menu. This menu has two sections. The first section contains commands that are handled by the hand; the second contains commands handled by the argument morph."
	| menu |
	menu _ MenuMorph new defaultTarget: self.
	menu addStayUpItem.
	menu add: 'grab' action: #grabMorph:.
	menu add: 'copy to paste buffer' action: #copyToPasteBuffer:.
	self maybeAddCollapseItemTo: menu.
	menu add: 'delete' action: #dismissMorph:.
	menu addLine.
	menu add: 'copy Postscript' action: #clipPostscript.
	menu add: 'print PS to file...' action: #printPSToFile.
	menu addLine.
	menu add: 'go behind' action: #goBehind.
	menu add: 'add halo' action: #addHalo:.
	menu add: 'duplicate' action: #maybeDuplicateMorph:.

	self potentialEmbeddingTargets size > 1 ifTrue:
		[menu add: 'embed...' action: #embedInto:].

	menu add: 'resize' action: #resizeMorph:.
	"Give the argument control over what should be done about fill styles"
	self addFillStyleMenuItems: menu hand: evt hand.
	self addDropShadowMenuItems: menu hand: evt hand.
	self addLayoutMenuItems: menu hand: evt hand.
	menu addUpdating: #hasClipSubmorphsString target: self selector: #changeClipSubmorphs argumentList: #().
	menu addLine.

	(self morphsAt: evt position) size > 1 ifTrue:
		[menu add: 'submorphs...'
			target: self
			selector: #invokeMetaMenuAt:event:
			argument: evt position].
	menu addLine.
	menu add: 'inspect' selector: #inspectAt:event: argument: evt position.
	menu add: 'explore' action: #explore.
	menu add: 'browse hierarchy' action: #browseHierarchy.
	menu add: 'make own subclass' action: #subclassMorph.
	menu addLine.
	menu add: 'set variable name...' action: #choosePartName.
	(self isMorphicModel) ifTrue:
		[menu add: 'save morph as prototype' action: #saveAsPrototype.
		(self ~~ self world modelOrNil) ifTrue:
			 [menu add: 'become this world''s model' action: #beThisWorldsModel]].
	menu add: 'save morph in file' action: #saveOnFile.
	(self hasProperty: #resourceFilePath)
		ifTrue: [((self valueOfProperty: #resourceFilePath) endsWith: '.morph')
				ifTrue: [menu add: 'save as resource' action: #saveAsResource].
				menu add: 'update from resource' action: #updateFromResource]
		ifFalse: [menu add: 'attach to resource' action: #attachToResource].
	menu add: 'show actions' action: #showActions.
	menu addLine.
	self addCustomMenuItems: menu hand: evt hand.
	^ menu
