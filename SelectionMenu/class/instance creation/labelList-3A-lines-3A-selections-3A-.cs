labelList: labelList lines: lines selections: selections
	^ self labels: (String streamContents:
			[:strm |  "Concatenate labels with CRs"
			labelList do: [:each | strm nextPutAll: each; cr].
			strm skip: -1])  "No CR at end"
		lines: lines selections: selections