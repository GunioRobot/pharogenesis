convertbosfcebbfgccpmcpbttloiairfidcuww0: varDict bosfcebbpmcpbttloiairfidcuww0: smartRefStrm
	"These variables are automatically stored into the new instance ('bounds' 'owner' 'submorphs' 'fullBounds' 'color' 'extension' 'borderWidth' 'borderColor' 'presenter' 'model' 'cursor' 'padding' 'backgroundMorph' 'turtleTrailsForm' 'turtlePen' 'lastTurtlePositions' 'openToDragNDrop' 'isPartsBin' 'autoLineLayout' 'indicateCursor' 'resizeToFit' 'fileName' 'isStackLike' 'dataInstances' 'currentDataInstance' 'userFrameRectangle' 'wantsMouseOverHalos' 'worldState' ).
	This method is for additional changes. Use statements like (foo _ varDict at: 'foo')."

	"These are going away ('fillColor2' 'gradientDirection' 'colorArray' 'colorDepth' ) because we don't subclass GradientFillMorph anymore. Instead, we create a fillstyle that hopefully looks alike."

	| color2 |
	color2 _ varDict at: 'fillColor2'.
	(color isColor and: [color2 isColor and: [color ~= color2]]) ifTrue: [
		self useGradientFill.
		self fillStyle
			colorRamp: {0.0 -> color. 1.0 -> color2};
			radial: false;
			origin: self position;
			direction: ((varDict at: 'gradientDirection') == #vertical 
				ifTrue:[0@self height] 
				ifFalse:[self width@0]).
	]