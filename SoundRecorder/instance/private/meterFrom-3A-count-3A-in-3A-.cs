meterFrom: start count: count in: buffer
	"Update the meter level with the maximum signal level in the given range of the given buffer."

	| last max sample |
	count = 0 ifTrue: [^ self].  "no new samples"
	last _ start + count - 1.
	max _ 0.
	start to: last do: [:i |
		sample _ buffer at: i.
		sample < 0 ifTrue: [sample _ sample negated].
		sample > max ifTrue: [max _ sample]].
	meterLevel _ max.
