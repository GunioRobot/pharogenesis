magnifiedForm
	| warp warpForm fromForm |

	savedExtent ~= srcExtent ifTrue: [
		savedExtent _ srcExtent.
		self calculateTransform].

	warpForm _ Form extent: srcExtent depth: Display depth.
	fromForm _ super magnifiedForm.

	warp _  (WarpBlt current toForm: warpForm)
		sourceForm: fromForm;
		colorMap: nil;
		cellSize: 2;
		combinationRule: Form over.

	1 to: gridNum y do: [:j |
		1 to: gridNum x do: [:i |
			warp
				clipRect: ((clipRects at: j) at: i);
				copyQuad: ((quads at: j) at: i)
					toRect: ((toRects at: j) at: i).
		].
	].
	^warpForm
