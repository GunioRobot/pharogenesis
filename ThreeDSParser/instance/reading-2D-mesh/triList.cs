triList
	"Subchunk of triMesh"
	| count triList triangle vertices flags smoothList matGroup |
	count := self uShort.
	triList := Array new: count.
	1 to: count do: [ :i |
		vertices := #(A B C) collect: [:j | self uShort + 1].
		flags := self uShort bitAnd: 7.
		triangle := vertices -> flags.
		triList at: i put: triangle].
	"May be followed by smoothlist"
	self recognize: #(
		(16r4150 smoothList ->) 
		(16r4130 cString materialGroup))
	do:[:item|
		#smoothList == item key
			ifTrue:[smoothList := item value].
		#materialGroup == item key
			ifTrue:[matGroup := item value].
	].
	^Array with: triList with: smoothList with: matGroup.