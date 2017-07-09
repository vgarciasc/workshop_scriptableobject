using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Skill Data", order = 1)]
public class SkillData : ScriptableObject {
	public string name = "DEFAULT SKILL";
	public List<Effect> effects;
	
	/*
	O que você quer na verdade é uma struct / classe que armazene essas funções.

	public List<EffectType> effectTypes;
	public List<float> durations;
	*/
}

public enum EffectType {BUFF, DEBUFF};

[System.Serializable] //sem isso, não é serializável
public class Effect {
	public EffectType type;
	public float duration;
}
