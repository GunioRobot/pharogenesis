allPathsDo: aBlock trail: trail
	"For all paths down the tree, evaluate aBlock."

	trail add: self.
	subAnalysises
		ifNil: [
			aBlock value: trail.]
		ifNotNil: [
			subAnalysises do: [:sub |
				sub allPathsDo: aBlock trail: trail]].
	trail removeLast