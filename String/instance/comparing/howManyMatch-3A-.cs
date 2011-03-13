howManyMatch: aString
	"Count the number of characters that match up in self and aString."

| count shorterLength |
count _ 0.
shorterLength _ self size min: aString size.
1 to: shorterLength do: [:index | 
	(self at: index) = (aString at: index) ifTrue: [
		count _ count + 1]].
^ count