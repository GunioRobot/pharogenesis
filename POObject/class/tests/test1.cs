test1
	"POObject test1"
	| to v1 v2 h t |
	to _ self new.
	v1 _ POVertex at: 0 @ 20.
	v2 _ (POVertex at: 20 @ 0)
				z: 10.
	h _ POHalfedge new origin: v1.
	t _ POHalfedge new origin: v2.
	h opposite: t.
	t opposite: h.
	(to eyeletsFor: h) inspect