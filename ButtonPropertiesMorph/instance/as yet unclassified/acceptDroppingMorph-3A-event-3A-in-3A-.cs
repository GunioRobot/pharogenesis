acceptDroppingMorph: aMorph event: evt in: aSubmorph

	| why |

	self clearDropHighlightingEvt: evt morph: aSubmorph.
	why _ aSubmorph valueOfProperty: #intentOfDroppedMorphs.
	why == #changeTargetMorph ifTrue: [
		self targetProperties replaceVisibleMorph: aMorph.
		myTarget _ aMorph.
		self rebuild.
		^true
	].
	why == #changeTargetTarget ifTrue: [
		(aMorph setAsActionInButtonProperties: self targetProperties) ifFalse: [
			^false
		].
		^true
	].
	why == #changeTargetMouseDownLook ifTrue: [
		self targetProperties mouseDownLook: aMorph.
		^false
	].
	why == #changeTargetMouseEnterLook ifTrue: [
		self targetProperties mouseEnterLook: aMorph.
		^false
	].

	^false
