drawSubmorphsOn: aCanvas
	"Display submorphs back to front"
	submorphs reverseDo:[:m | aCanvas fullDrawMorph: m].
