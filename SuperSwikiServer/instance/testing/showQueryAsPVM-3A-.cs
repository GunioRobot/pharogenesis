showQueryAsPVM: resultStream
	| answer gif whatToShow projectName fileName firstURL wrapper currX currY maxX maxY rawProjectName |
"SuperSwikiServer testOnlySuperSwiki queryProjectsAndShow"

	resultStream reset; nextLine.
	answer _ RectangleMorph new
		useRoundedCorners;
		borderWidth: 0;
		borderColor: Color blue;
		color: Color paleBlue.
	currX _ currY _ maxX _ maxY _ 10.
	[resultStream atEnd] whileFalse: [
		rawProjectName _ resultStream nextLine.
		projectName _ rawProjectName convertFromEncoding: self encodingName.
		fileName _ resultStream nextLine convertFromEncoding: self encodingName.
		gif _ self oldFileOrNoneNamed: rawProjectName,'.gif'.
		gif ifNotNil: [gif _ GIFReadWriter formFromStream: gif].
		currX > 600 ifTrue: [
			currX _ 10.
			currY _ maxY + 10.
		].
		gif ifNil: [
			gif _ AlignmentMorph newColumn
				hResizing: #shrinkWrap;
				vResizing: #shrinkWrap;
				borderWidth: 8;
				borderColor: Color red;
				color: Color lightRed;
				addMorph: (StringMorph contents: 'No GIF for ',projectName);
				fullBounds;
				imageForm
		].
		firstURL _ self url.
		firstURL last == $/ ifFalse: [firstURL _ firstURL, '/'].

		whatToShow _ ProjectViewMorph new
			image: (gif asFormOfDepth: Display depth);
			lastProjectThumbnail: gif;
			setProperty: #SafeProjectName toValue: projectName;
			project: (DiskProxy 
				global: #Project 
				selector: #namedUrl: 
				args: {firstURL,fileName}
			).

		answer addMorphBack: (whatToShow position: currX @ currY).
		currX _ currX + whatToShow width + 10.
		maxX _ maxX max: currX.
		maxY _ maxY max: currY + whatToShow height.
	].
	maxX = 10 ifTrue: [
		^self inform: 'No projects found for your criteria'
	].
	answer extent: (maxX @ maxY) + (0@10).
	wrapper _ ScrollPane new extent: (answer width + 10) @ (answer height min: 400).
	wrapper color: Color white.
	wrapper scroller addMorph: answer.
	wrapper 
		becomeModal;
		openCenteredInWorld;
		useRoundedCorners;
		setScrollDeltas.