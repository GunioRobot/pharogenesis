likelyEqual: otherIndexFileEntry
	"return true if the two toc entries seem to represent the same message"
	^(self textLength = otherIndexFileEntry textLength and: [self subject = otherIndexFileEntry subject]) and: [self from = otherIndexFileEntry from]