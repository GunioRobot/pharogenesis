putOnBackground
	"Place the receiver, formerly private to its card, onto the shared background.  If the receiver needs data carried on its behalf by the card, such data will be represented on every card."

	"If I seem to have per-card data, then set that up."
	target class superclass == CardPlayer ifTrue: [
		(self hasOwner: target costume) ifTrue: [	
			self setProperty: #holdsSeparateDataForEachInstance toValue: true]].
	super putOnBackground.