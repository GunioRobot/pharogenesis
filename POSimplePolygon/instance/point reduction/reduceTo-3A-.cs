reduceTo: reduceLength 
	| stream start end ahead cumulativeAngle cumulativeLength reduced aheadVector endVector angle found |
	stream _ ReadStream on: self vertices.
	start _ stream next.
	end _ stream next.
	reduced _ OrderedCollection with: start.
	[stream atEnd]
		whileFalse: 
			[cumulativeAngle _ 0.
			cumulativeLength _ 0.
			endVector _ start - end.
			found _ false.
			[found or: [stream atEnd]]
				whileFalse: 
					[ahead _ stream next.
					aheadVector _ end - ahead.
					angle _ endVector theta - aheadVector theta.
					cumulativeAngle _ cumulativeAngle + angle.
					cumulativeLength _ cumulativeLength + endVector r.
					(cumulativeAngle abs > 0.2 or: [cumulativeLength > reduceLength])
						ifTrue: 
							[reduced add: end.
							found _ true].
					found
						ifFalse: 
							[end _ ahead.
							endVector _ aheadVector]].
			start _ end.
			end _ ahead].
	self vertices: reduced