performanceTestSwitchToMorphClassCategoryScenario
	"When changing in one browser the selected category, we add some interesting classes, remove some others, and calculate some values. So this is a pretty full life cycle test."
	| noLongerInteresting newInteresting |
	RequiredSelectors doWithTemporaryInstance: 
			[LocalSends doWithTemporaryInstance: 
					[ProvidedSelectors doWithTemporaryInstance: 
							[self prepareAllCaches.
							noLongerInteresting := self classesInCategories: {'Morphic-Basic'}.
							newInteresting := self classesInCategories: {'Morphic-Kernel'}.
							self measure: 
									[self noteInterestInClasses: newInteresting.
									self loseInterestInClasses: noLongerInteresting.
									newInteresting do: [:cl | cl hasRequiredSelectors].
									self loseInterestInClasses: newInteresting.
									self noteInterestInClasses: noLongerInteresting.].
							self assert: realTime < 500]]]