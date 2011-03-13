performanceTestMethodChangeScenario
	RequiredSelectors doWithTemporaryInstance: [
		LocalSends doWithTemporaryInstance: [
			ProvidedSelectors doWithTemporaryInstance: [
				self prepareAllCaches.
				self measure: 
						[self touchObjectHalt.
						displayedClasses do: [:cl | cl hasRequiredSelectors].
						focusedClasses do: [:cl | cl requiredSelectors]].
				self assert: realTime < 200]]]