﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

	public Transform enemyPrefab;
	public Transform spawnPoint;
	public Text waveCountdownTimer;

	public float timeBetweenWaves = 5f;
	private float countDown = 2f;
	private int waveIndex = 0;

	void Update () 
	{
		if (countDown <= 0f) {
			StartCoroutine(SpawnWave ());
			countDown = timeBetweenWaves;
		}
	
		countDown -= Time.deltaTime;

		countDown = Mathf.Clamp (countDown, 0f, Mathf.Infinity);
		waveCountdownTimer.text = string.Format("{0:00.00}", countDown);
	}	

	IEnumerator SpawnWave(){
		waveIndex++;
		Currency.Rounds++;
		for (int i = 0; i < waveIndex; i++) {
			SpawnEnemy ();
			yield return new WaitForSeconds (0.5f);
		}
	}

	void SpawnEnemy(){
		Instantiate (enemyPrefab, spawnPoint.position, spawnPoint.rotation);
	}
}