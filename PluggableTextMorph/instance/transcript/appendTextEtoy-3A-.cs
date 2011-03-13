appendTextEtoy: moreText
	"Append the text in the model's writeStream to the editable text. "

	self 
		selectInvisiblyFrom: textMorph asText size + 1 to: textMorph asText size;
		replaceSelectionWith: moreText;
		selectFrom: textMorph asText size + 1 to: textMorph asText size;
		hasUnacceptedEdits: false;
		scrollSelectionIntoView;
		changed