adjustToTextureIfNecessary
	| texExtent texRatio myExtent myRatio |
	"Adjust the receiver to the texture extent if necessary"
	(self getProperty: #adjustToTexture) == true ifFalse:[^self]. "Don't adjust"
	texExtent _ self getTexturePointer extent.
	texRatio _ texExtent x / texExtent y.
	myExtent _ self getBoundingBox extent.
	myRatio _ myExtent x / myExtent y.
	self resize: (Array with: texRatio / myRatio with: 1.0 with: 1.0) duration: 2