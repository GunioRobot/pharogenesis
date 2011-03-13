openWithStandardPartsBinShowing
	"WorldMorph openWithStandardPartsBinShowing"
	| aWorld anExtent |
	anExtent _  700 @ 500.
	aWorld _ self new setProperty: #initialExtent toValue: anExtent.
	aWorld extent: anExtent.
	aWorld presenter addTrashCan; standardPlayer.
	aWorld addMorph: ((aWorld presenter newStandardPartsBin) position: 10@10).
	MorphWorldView openOn: aWorld label: 'Construction' extent: anExtent