displayOn: aCanvas using: displayScanner at: somePosition
	"Send all visible lines to the displayScanner for display"
	| maxExtent lineForm leftInRun lineRect warp sourceQuad backgroundColor lineCanvas |
	warp _ nil.
	self textSegmentsDo:
		[:line :destRect :segStart :segAngle |
		false ifTrue:
			["Show the dest rects for debugging..."
			aCanvas frameRectangle: destRect width: 1 color: Color black].
		(aCanvas isVisible: destRect) ifTrue:
			[warp ifNil:
				["Lazy initialization because may hot have to display at all."
				maxExtent _ lines inject: lines first rectangle extent 
					into: [:maxWid :lin | maxWid max: lin rectangle extent].
				lineForm _ Form extent: maxExtent depth: aCanvas depth.
				displayScanner setDestForm: lineForm.
				lineRect _ lineForm boundingBox.
				leftInRun _ 0.
				backgroundColor _ (curve borderWidth > 10
							ifTrue: [curve color]
							ifFalse: [curve owner isHandMorph
									ifTrue: [curve owner owner color]
									ifFalse: [curve owner color]]) dominantColor.
				warp _ (aCanvas warpFrom: lineRect corners toRect: lineRect)
						cellSize: 2;  "installs a colormap if smoothing > 1"
						sourceForm: lineForm.
				warp colorMap: (self warpMapForDepth: aCanvas depth
									withTransparentFor: backgroundColor).
				lineCanvas _ lineForm getCanvas].
			sourceQuad _ destRect innerCorners collect:
				[:p | self pointInLine: line forDestPoint: p
						segStart: segStart segAngle: segAngle].
			lineForm fill: lineForm boundingBox fillColor: backgroundColor.
			self displaySelectionInLine: line on: lineCanvas.
			leftInRun _ displayScanner displayLine: line offset: 0@0 leftInRun: leftInRun.
			warp sourceQuad: sourceQuad destRect: (destRect translateBy: aCanvas origin).
			warp warpBits]].
