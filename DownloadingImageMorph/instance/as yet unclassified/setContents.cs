setContents
	"set up our morphic contents"
	| imageMorph imageMap |
	self removeAllMorphs.

	image ifNil: [^self setNoImageContents].

	imageMorph _ ImageMorph new.
	(imageMapName notNil
	and: [formatter notNil
	and: [(imageMap _ formatter imageMapNamed: imageMapName) notNil]])
		ifTrue: [imageMap buildImageMapForImage: imageMorph andBrowser: formatter browser].

	imageMorph image: image.
	imageMorph position: self position.
	self addMorph: imageMorph.
	imageMorph extent ~= self extent
		ifTrue: [self extent: imageMorph extent].