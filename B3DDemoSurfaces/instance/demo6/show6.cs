show6

    " B3DDemoSurfaces new show6"

     | view |

  self createScene6.
  (view := B3DTutorialScenePresenterMorph new)
     source: self description: #descriptionScene6;
     scene: scene.
  view clearColor: (Color gray: 0.86).

  
  view addFrameAndExplanationField openInWorldExtent: Display extent x//2 @ (Display extent y * 7 // 8).