scene
	"Whole file"
	| renderObjects |
	self chunkHeader.
	chunkID == 16r3D3D ifTrue: [^self meshData].
	chunkID == 16r4D4D ifFalse: [^nil].
	self recognize: #(
		(16r3D3D meshData 1)
		(16rB000 keyframeData 2)
		) do: [:item | self indexed: item
			do: [:data | renderObjects := data]
			do: [:data | (renderObjects at: #globals) at: #keyframes put: data]].
	^renderObjects