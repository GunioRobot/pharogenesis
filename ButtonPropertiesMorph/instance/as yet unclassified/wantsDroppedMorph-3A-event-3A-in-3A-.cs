wantsDroppedMorph: aMorph event: evt in: aSubmorph

	| why |

	why _ aSubmorph valueOfProperty: #intentOfDroppedMorphs.
	^why notNil

" toValue: #changeTargetMorph.

	^true"