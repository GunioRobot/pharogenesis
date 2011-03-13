dilate: amount
	| irisCenter |
	irisCenter := self iris center.
	self iris extent: self iris extent * amount.
	self iris position: irisCenter - self iris center + self iris position