mergeBlobs
	"See if we need to merge by checking our bounds against all other Blob
	bounds, then all our vertices against any Blob with overlapping bounds.
	If we find a need to merge, then someone else does all the work."

	(AllBlobs isNil or: [AllBlobs size < 2]) 
		ifTrue: [^ self].
	AllBlobs
		do:
			[:aBlob |
			aBlob owner == self owner ifTrue:
				[(self bounds intersects: aBlob bounds) ifTrue:
					[vertices do:
						[:aPoint |
						(aBlob containsPoint: aPoint) ifTrue:
							[^ self mergeSelfWithBlob: aBlob atPoint: aPoint]]]]]
		without: self