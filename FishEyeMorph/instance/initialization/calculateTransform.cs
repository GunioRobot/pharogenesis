calculateTransform
	| stepX stepY rect tx ty arrayX arrayY |
	(gridNum x = 0 or: [gridNum y = 0]) ifTrue: [^self].
	stepX _ srcExtent x // gridNum x.
	stepY _ srcExtent y // gridNum y.

	arrayX _ (1 to: gridNum y + 1) collect: [:j | FloatArray new: gridNum x + 1].
	arrayY _ (1 to: gridNum y + 1) collect: [:j |  FloatArray new: gridNum x + 1].

	0 to: gridNum y do: [:j |
		0 to: gridNum x do: [:i |
			(arrayX at: (j + 1)) at: (i + 1) put: i*stepX.
			(arrayY at: (j + 1)) at: (i + 1) put: j*stepY.
		].
	].

	0 to: gridNum y do: [:j |
		self transformX: (arrayX at: (j+1)).
		self transformY: (arrayY at: (j+1)).
	].

	0 to: gridNum y do: [:j |
		arrayX at: (j+1) put: ((1 to: gridNum x +1) collect: [:i | ((arrayX at: (j+1)) at: i) asInteger]).
		arrayY at: (j+1) put: ((1 to: gridNum x +1) collect: [:i | ((arrayY at: (j+1)) at: i) asInteger]).
	].


	clipRects _ (1 to: gridNum y) collect: [:j | Array new: gridNum x].
	toRects _ (1 to: gridNum y) collect: [:j |  Array new: gridNum x].
	quads _ (1 to: gridNum y) collect: [:j |  Array new: gridNum x].
	0 to: gridNum y - 1 do: [:j |
		0 to: gridNum x- 1 do: [:i |
			rect _ (((arrayX at: (j+1)) at: (i+1))@((arrayY at: (j+1)) at: (i+1)))
						corner: ((arrayX at: (j+2)) at: (i+2))@((arrayY at: (j+2)) at: (i+2)).
			(clipRects at: j+1) at: i+1 put: rect.

			rect width >= stepX ifTrue: [rect _ rect expandBy: (1@0)].
			rect height >= stepY ifTrue: [rect _ rect expandBy: (0@1)].
			(toRects at: j+1) at: i+1 put: rect.

			tx _ (i)*stepX.
			ty _ (j)*stepY.
			(quads at: j+1) at: i+1
						put: {(tx)@(ty). (tx)@(ty+stepY). (tx+stepX)@(ty+stepY). (tx+stepX)@(ty)}.
		].
	].

