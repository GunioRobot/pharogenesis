asGregorian
	"Return an array of integers #(dd mm yyyy)"

	^ self
		deprecated: 'Use #dayMonthYearDo:';
		dayMonthYearDo: [ :d :m :y | { d. m. y } ] 
