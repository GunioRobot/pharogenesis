customButtonRow
	"Answer a custom row of widgets, which pertain primarily to within-tool navigation"

	| aRow aButton aLabel |
	aRow _ AlignmentMorph newRow.
	aRow setNameTo: 'navigation controls'.
	aRow beSticky.
	aRow hResizing: #spaceFill.
	aRow wrapCentering: #center; cellPositioning: #leftCenter.
	aRow clipSubmorphs: true.
	aRow cellInset: 3.

	self customButtonSpecs  do:
		[:triplet |
			aButton _ PluggableButtonMorph
				on: self
				getState: nil
				action: triplet second.
			aButton 
				useRoundedCorners;
				hResizing: #spaceFill;
				vResizing: #spaceFill;
				onColor: Color transparent offColor: Color transparent.
			aLabel _ Preferences abbreviatedBrowserButtons 
				ifTrue: [self abbreviatedWordingFor: triplet second]
				ifFalse: [nil].
			aButton label: (aLabel ifNil: [triplet first asString])
				" font: (StrikeFont familyName: 'Atlanta' size: 9)".
			triplet size > 2 ifTrue: [aButton setBalloonText: triplet third].
			triplet size > 3 ifTrue: [aButton triggerOnMouseDown: triplet fourth].
			aRow addMorphBack: aButton].

	aRow addMorphBack: self homeCategoryButton.
	aRow addMorphFront: (Morph new extent: (4@10)) beTransparent.
	aRow addMorphFront: self mostGenericButton.
	aRow addMorphFront: self menuButton.

	^ aRow