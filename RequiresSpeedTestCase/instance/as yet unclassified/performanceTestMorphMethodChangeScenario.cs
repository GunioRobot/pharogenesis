performanceTestMorphMethodChangeScenario
	RequiredSelectors doWithTemporaryInstance: 
			[LocalSends doWithTemporaryInstance: 
					[ProvidedSelectors doWithTemporaryInstance: 
							[self prepareAllCaches.
							self measure: 
									[self touchMorphStep.
									displayedClasses do: [:cl | cl hasRequiredSelectors].
									focusedClasses do: [:cl | cl requiredSelectors]].
							self assert: realTime < 200]]]